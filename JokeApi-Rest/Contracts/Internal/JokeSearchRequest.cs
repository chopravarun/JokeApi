using System.Web;

public class JokeSearchRequest {
    public String _term {get;}

    public int _page {get;}

    public int _limit{get;}

    public JokeSearchRequest(String term, int? page, int? limit){
        _term = HttpUtility.HtmlEncode(term);
        int tmpPage = page ?? 1;
        _page = tmpPage < 0 ? 0:tmpPage;
        int tmp = (limit ?? 20); 
        _limit =  tmp > 30 ? 30:tmp<0?0:tmp;
    }

    public override string ToString()
    {
        return $"term : {_term}, page : {_page}, limit : {_limit}";
    }


}