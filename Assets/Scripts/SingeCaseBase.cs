
public class SingeCaseBase<T> where T :new()
{
    private T instance;

    public T Instance
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
