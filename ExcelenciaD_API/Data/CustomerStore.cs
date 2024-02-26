using ExcelenciaD_API.Models.Dto;

namespace ExcelenciaD_API.Data
{
    public static class CustomerStore
    {
        public static List<CustomerDto> customerList = new List<CustomerDto>
        {
            new CustomerDto {Id = 1 , Name = "Claudio David"},
            new CustomerDto {Id = 2 , Name = "Casagrande Bethouart"}

        };
    }
}
