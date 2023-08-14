public class JokeSearchRequest {
    public String _term {get;}

    public int _page {get;}

    public int _limit{get;}

    public JokeSearchRequest(String term, int? page, int? limit){
        _term = term;
        _page = page ?? 1;
        int tmp = (limit ?? 20); 
        _limit =  tmp > 30 ? 30:tmp;
    }

    public override string ToString()
    {
        return $"term : {_term}, page : {_page}, limit : {_limit}";
    }


}