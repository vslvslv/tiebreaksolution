﻿namespace DummyClient.Models.Response
{
    public class CreateRequestTokenResponseDto
    {
        public bool success { get; set; }
        public string expires_at { get; set; }
        public string request_token { get; set; }
    }
}
