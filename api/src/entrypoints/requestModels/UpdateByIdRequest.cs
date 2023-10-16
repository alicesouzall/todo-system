namespace requestModels
{
    public class UpdateByIdRequest
    {
        public UpdateByIdRequest()
        {
            this.ColTexto = "";
        }
        public int Id { get; set; }
        public string ColTexto { get; set; }
    }
}
