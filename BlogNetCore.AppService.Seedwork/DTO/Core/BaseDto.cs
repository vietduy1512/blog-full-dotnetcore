namespace BlogNetCore.AppService.Seedwork.DTO.Core
{
    public abstract class BaseDto<TId>
    {
        public TId Id { get; set; }
    }
}
