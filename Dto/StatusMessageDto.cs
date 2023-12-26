using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EgrnClient.Dto;
public class StatusMessageDto
{
    public StatusMessageDto()
    {
        Statuses = new List<StatusMessageStatusDto>();
    }

    public string RequestNumber { get; set; }

    /// <summary>
    /// Принято от заявителя
    /// </summary>
    public string[] KudNumbers { get; set; }

    /// <summary>
    /// Сформирована квитанция
    /// </summary>
    public string[] Uins { get; set; }

    public string ChargeAmount { get; set; }

    /// <summary>
    /// Проверка не пройдена
    /// </summary>
    public string ErrorMessage { get; set; }

    public bool IsCompleted { get; set; }

    public ICollection<StatusMessageStatusDto> Statuses { get; set; }
}

public class StatusMessageStatusDto
{
    public Guid? ResponseId { get; set; }

    public string Code { get; set; }

    public string Description { get; set; }

    public DateTime Time { get; set; }

    public string FileLink { get; set; }
}