using Ardalis.Result;
using EgrnClient.Dto;

namespace EgrnClient;
public interface IEgrnClient
{
    /// <summary>
    /// Загрузка пакета в сервис (без статуса на отправления).
    /// </summary>
    /// <param name="storageId"></param>
    /// <param name="rusFedSubject"></param>
    /// <param name="ct"></param>
    /// <returns></returns>
    Task<Result<PackageRequestDto>> PackageCreateAsync(string filePath, string fileName, RusFedSubjects rusFedSubject, CancellationToken ct);

    /// <summary>
    /// Отметка пакета на отправку
    /// </summary>
    /// <param name="packageModel"></param>
    /// <param name="ct"></param>
    /// <returns></returns>
    Task<Result> PackageSendingAsync(PackageRequestDto packageModel, CancellationToken ct);

    /// <summary>
    /// Получение статусов для пакета
    /// </summary>
    /// <param name="packageModel"></param>
    /// <param name="ct"></param>
    /// <returns></returns>
    Task<Result<StatusResponseDto[]>> StatusGetAllAsync(StatusGetRequestDto packageModel, CancellationToken ct);

    /// <summary>
    /// Подтверждение получения статуса
    /// </summary>
    /// <param name="statusModel"></param>
    /// <param name="ct"></param>
    /// <returns></returns>
    Task<Result> ConfirmationStatusReceiptAsync(ConfirmationStatusRequestDto statusModel, CancellationToken ct);
}
