public class JokeSearchResponseExternal
{
    public List<JokeExternal> small {get;set;}

    public List<JokeExternal> medium {get;set;}

    public List<JokeExternal> large {get;set;} 

    public JokeSearchResponseExternal(){
        small = new List<JokeExternal>();
        medium = new List<JokeExternal>();
        large = new List<JokeExternal>();
    }

    public bool hasJokes(){
        return small.Count>0 || medium.Count>0 || large.Count>0;
    }

    public override string ToString()
    {
        return $"small jokes : {small.Count}, medium jokes : {medium.Count}, large jokes : {large.Count}";
    }
}