namespace Models;

public abstract class BaseGameEntity
{
    public int id{get;set;}
    public string? name{get;set;} = "";
    public int hp{get;set;} = 0;
    public int atk{get;set;} = 0;
    public int def{get;set;} = 0;
    public int spatk{get;set;} = 0;
    public int spdef{get;set;} = 0;
    public int spd{get;set;} = 0;
    public int type1{get;set;} = 0;
    public int type2{get;set;} = 0;
    public string ability{get;set;} = "none";

}