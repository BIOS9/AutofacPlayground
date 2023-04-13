using System.ComponentModel.DataAnnotations;

namespace AutofacTest.Services.ServiceOne;

public class Service1Options
{
    public const string Name = "ServiceOne";

    [Required]
    public string Thing { get; init; } = String.Empty;
}