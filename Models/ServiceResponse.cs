namespace SteamCopyCat.Models
{
    public class ServiceResponse<T>
    {
        public T? Data { get; set; }
        public bool Sucess { get; set; }
        public string Messaget { get; set; }
    }
}
