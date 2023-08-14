public class JokeExternal
{
    public String joke{get;set;}

    public JokeExternal(String joke){
        this.joke = joke;
    }

    public bool hasJoke(){
        String tmpJoke = joke ?? String.Empty;
        return !String.Empty.Equals(tmpJoke);
    }
}