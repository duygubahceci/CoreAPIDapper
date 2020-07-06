using Newtonsoft.Json;

namespace CoreAPIDapper.ServiceResponse
{
    public class ServiceResponse<T> 
    {
        public T Data { get; set; }
        public bool Success{get;set;} =true;
        
         [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string Message { get; set; } = null;
    }
}