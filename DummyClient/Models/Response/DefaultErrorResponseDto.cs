namespace DummyClient.Models.Response
{
    public class DefaultErrorResponseDto
    {
        public int status_code { get; set; }
        public string status_message { get; set; }
        public bool success { get; set; }
    }
}
