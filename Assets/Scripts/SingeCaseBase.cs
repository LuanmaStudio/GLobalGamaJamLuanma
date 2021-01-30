
public class SingeCaseBase<T> where T :new()
{
    private static T instance;

    public static T Instance
    {
        get
        {
            if (instance != null) return instance;
            return instance = new T();
        }
        private set
        {
            instance = value;
        }
    }
}
