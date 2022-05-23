namespace CE.Domain.Enums
{
    public class STATUSES
    {
        public const string IN_PROGRESS = nameof(IN_PROGRESS);
        public const string SHIPPED = nameof(SHIPPED);
        public const string IN_BACKORDER = nameof(IN_BACKORDER);
        public const string MANCO = nameof(MANCO);
        public const string CANCELED = nameof(CANCELED);
        public const string IN_COMBI = nameof(IN_COMBI);
        public const string CLOSED = nameof(CLOSED);
        public const string NEW = nameof(NEW);
        public const string RETURNED = nameof(RETURNED);
        public const string REQUIRES_CORRECTION = nameof(REQUIRES_CORRECTION);
        public const string AWAITING_PAYMENT = nameof(AWAITING_PAYMENT);
    }
}
