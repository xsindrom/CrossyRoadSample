namespace Utils
{
    public interface IPoolObject
    {
        string Id { get;  }
        void Release();
    }
}