namespace Odusseus.Rules.Model
{
    public class Condition
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        public IOperation Operation { get; set; }
    }
}