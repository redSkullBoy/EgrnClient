using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EgrnClient.Dto;
public class StatusResponseDto
{
    public Guid PackageId { get; set; }
    public StatusMessageDto Value { get; set; }
}