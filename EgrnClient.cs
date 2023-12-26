using Ardalis.Result;
using System.Net.Http.Headers;
using System.Net;
using System.Text;
using Newtonsoft.Json.Serialization;
using Newtonsoft.Json;
using Microsoft.Extensions.Options;
using EgrnClient.Dto;

namespace EgrnClient;
public class EgrnClient : IEgrnClient
{
    private string _token;

    private readonly EgrnServiceOptions _apiConfig;

    public EgrnClient(IOptions<EgrnServiceOptions> apiConfig)
    {
        _apiConfig = apiConfig.Value;
        _token = apiConfig.Value.ApiKey;
    }

    public async Task<Result<PackageRequestDto>> PackageCreateAsync(string filePath, string fileName, RusFedSubjects rusFedSubject, CancellationToken ct)
    {
        var client = new HttpClient();

        if (string.IsNullOrEmpty(filePath)) return Result.NotFound();

        var formData = new MultipartFormDataContent
        {
            { new StringContent(((int)rusFedSubject).ToString()), "regionCode" },
        };

        byte[] buffer = null;
        using (var fs = new FileStream(filePath, FileMode.Open, FileAccess.Read))
        {
            buffer = new byte[fs.Length];
            fs.Read(buffer, 0, (int)fs.Length);
        }

        var formDoc = new ByteArrayContent(buffer);
        formData.Add(formDoc, "packageFile", fileName);

        var url = $"{_apiConfig.BaseUrl}/package/create";
        try
        {
            using (var httpRequest = CreateHttpRequest(verb: HttpMethod.Post, url: url, "multipart/form-data"))
            using (var httpContent = formData)
            {
                httpRequest.Content = httpContent;
                using (var httpResponse = await client.SendAsync(httpRequest, ct))
                {
                    var message = await httpResponse.Content.ReadAsStringAsync();

                    if (httpResponse.StatusCode == HttpStatusCode.OK)
                    {
                        var result = await Deserialize<PackageRequestDto>(httpResponse);

                        return Result<PackageRequestDto>.Success(result);
                    }

                    return Result.Invalid(new List<ValidationError> {
                            new ValidationError { Identifier = "PackageCreateAsync", ErrorMessage = $"Вернул статус ошибки {httpResponse.StatusCode}" }
                        });
                }
            }
        }
        catch (Exception ex)
        {
            return Result.Invalid(new List<ValidationError> {
                    new ValidationError { Identifier = "PackageCreateAsync.SendAsync", ErrorMessage = $"Ошибка запроса {url}" }
                });
        }
    }

    public async Task<Result> PackageSendingAsync(PackageRequestDto packageModel, CancellationToken ct)
    {
        var client = new HttpClient();
        using (var httpRequest = CreateHttpRequest(verb: HttpMethod.Get, url: $"{_apiConfig.BaseUrl}/package/sending", "application/json"))
        using (var httpContent = Serialize(httpRequest, packageModel))
        {
            httpRequest.Content = httpContent;
            using (var httpResponse = await client.SendAsync(httpRequest, ct))
            {
                if (httpResponse.StatusCode == HttpStatusCode.OK)
                {
                    var result = await httpResponse.Content.ReadAsStringAsync();

                    return Result.Success();
                }
            }
        }

        return Result.Invalid(new List<ValidationError> {
                    new ValidationError { Identifier = "PackageSendingAsync", ErrorMessage = $"Ошибка изменения статуса пакета" }
                });
    }

    public async Task<Result<StatusResponseDto[]>> StatusGetAllAsync(StatusGetRequestDto packageModel, CancellationToken ct)
    {
        var client = new HttpClient();
        
        using (var httpRequest = CreateHttpRequest(verb: HttpMethod.Get, url: $"{_apiConfig.BaseUrl}/status/all", "application/json"))
        {
            string packageIdsString = string.Join("&PackageIds=", packageModel.PackageIds);
            httpRequest.RequestUri = new Uri($"{_apiConfig.BaseUrl}/status/all?PackageIds={packageIdsString}");
            try
            {
                using (var httpResponse = await client.SendAsync(httpRequest, ct))
                {
                    if (httpResponse.StatusCode == HttpStatusCode.OK)
                    {
                        var text = await httpResponse.Content.ReadAsStringAsync();

                        var result = await Deserialize<StatusResponseDto[]>(httpResponse);

                        return Result<StatusResponseDto[]>.Success(result);
                    }

                    return Result.Invalid(new List<ValidationError> {
                            new ValidationError { Identifier = "StatusGetAllAsync", ErrorMessage = $"Вернул статус ошибки {httpResponse.StatusCode}" }
                        });
                }
            }
            catch (Exception ex)
            {
                return Result.Error(ex.Message);
            }
        }
    }

    public async Task<Result> ConfirmationStatusReceiptAsync(ConfirmationStatusRequestDto statusModel, CancellationToken ct)
    {
        try
        {
            var client = new HttpClient();
            using (var httpRequest = CreateHttpRequest(verb: HttpMethod.Post, url: $"{_apiConfig.BaseUrl}/status/confirmation", "application/json"))
            using (var httpContent = Serialize(httpRequest, statusModel))
            {
                httpRequest.Content = httpContent;
                using (var httpResponse = await client.SendAsync(httpRequest, ct))
                {
                    if (httpResponse.StatusCode == HttpStatusCode.OK || httpResponse.StatusCode == HttpStatusCode.NotFound)
                    {
                        var text = await httpResponse.Content.ReadAsStringAsync();

                        return Result.Success();
                    }

                    return Result.Invalid(new List<ValidationError> {
                        new ValidationError { Identifier = "ConfirmationStatusReceiptAsync", ErrorMessage = $"Вернул статус ошибки {httpResponse.StatusCode}" }
                    });
                }
            }
        }
        catch (Exception ex)
        {
            return Result.Error(ex.Message);
        }
    }

    protected HttpRequestMessage CreateHttpRequest(HttpMethod verb, string url, string accept)
    {
        if (string.IsNullOrWhiteSpace(_token)) throw new ArgumentNullException(nameof(_token)); ;

        var request = new HttpRequestMessage(verb, url);

        request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue(accept));

        request.Headers.Add("x-api-key", _token);

        return request;
    }

    protected virtual async Task<T> Deserialize<T>(HttpResponseMessage httpResponse)
    {
        var stream = await httpResponse.Content.ReadAsStreamAsync();
        using (var r = new StreamReader(stream))
        {
            string responseText = await r.ReadToEndAsync();
            var obj = await Task.Run(() => JsonConvert.DeserializeObject<T>(responseText));
            return obj;
        }
    }

    protected HttpContent Serialize(HttpRequestMessage httpRequest, IRequest request)
    {
        DefaultContractResolver contractResolver = new DefaultContractResolver
        {
            NamingStrategy = new CamelCaseNamingStrategy()
        };

        string json = JsonConvert.SerializeObject(request, new JsonSerializerSettings
        {
            ContractResolver = contractResolver,
            Formatting = Newtonsoft.Json.Formatting.Indented
        });

        var httpContent = new StringContent(json, Encoding.UTF8);

        httpContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");

        return httpContent;
    }
}