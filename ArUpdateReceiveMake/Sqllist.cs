namespace ArUpdateReceiveMake
{
    public class Sqllist
    {
        private string _result;

        public string UpdateMake(string ordernolist)
        {
            _result = $@"
                            UPDATE T_AR_RECEIVABLE SET F_YTC_TEXT20='已完成'
                            WHERE FBILLNO in ({ordernolist})
                        ";

            return _result;
        }
    }
}
