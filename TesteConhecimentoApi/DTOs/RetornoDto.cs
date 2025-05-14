namespace TesteConhecimentoApi.DTOs
{
    public class RetornoDto<T>
    {
        public bool Status { get; set; }
        public string Msg { get; set; }
        public T? Data { get; set; }
    }
}
