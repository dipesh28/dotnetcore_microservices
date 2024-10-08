using System.ComponentModel.DataAnnotations;

namespace PlatformService.Dtos
{
    public class PlatformCreateDto {
        [Required]
        public int Id { get; set;}   
        [Required]
        public string Name { get; set;}
        [Required]
        public string Publisher { get; set;}
        [Required]
        public string Cost { get; set;} 
    }
}