using CourtReservation_Infraestructure.Dto_s;

namespace CourtReservation_Api.Responses
{
    public class ApiResponse<T>
    {
       

        public T Data { get; set; }
        public ApiResponse(T data)
        {
            Data = data;
        }
        public string Message { get; set; } 
        public bool Success { get; set; }  
        public int StatusCode { get; set; } 
    }

}