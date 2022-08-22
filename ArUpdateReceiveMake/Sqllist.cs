namespace ArUpdateReceiveMake
{
    public class Sqllist
    {
        private string _result;

        public string UpdateMake(string ordernolist)
        {
            _result = $@"
                            UPDATE T_AR_RECEIVABLE SET F_YTC_TEXT20='已完成'
                            WHERE doc_no in ({ordernolist})
                        ";

            return _result;
        }
    }
}
