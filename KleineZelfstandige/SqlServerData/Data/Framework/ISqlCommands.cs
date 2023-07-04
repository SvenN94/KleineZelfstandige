namespace SqlServerData.Data.Framework
{
    internal interface ISqlCommands<T>
    {
        SelectResult Select();
        InsertResult Insert(T t);
        UpdateResult Update(T t);
        DeleteResult Delete(T t);
    }
}
