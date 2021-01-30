
using System.Collections.Generic;

public class ReloadManager : SingeCaseBase<ReloadManager>
{
    public List<IRestart> List = new List<IRestart>();
    
    public void Reset()
    {
        foreach (var item in List)
        {
            item.Reset();
        }
    }
    
    
}

public interface IRestart
{
    void Reset();
}
