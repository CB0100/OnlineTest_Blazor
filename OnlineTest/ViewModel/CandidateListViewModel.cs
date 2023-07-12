using OnlineTest.Data;

namespace OnlineTest.ViewModel
{
    public class CandidateListViewModel
    {
        public TblCandidate? candidate { get; set; }
        public Country? country { get; set; }
        public State? state { get; set; }
    }
}