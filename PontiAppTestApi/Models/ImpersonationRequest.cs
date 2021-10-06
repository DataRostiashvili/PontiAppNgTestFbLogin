using System.Text.Json.Serialization;

namespace WebApplication.Models
{
    public class ImpersonationRequest
    {
        [JsonPropertyName("username")]
        public string UserName { get; set; }
    }
}