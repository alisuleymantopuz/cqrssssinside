using System;
namespace cqrssssinside.domain.infrastructure.Data
{
    public class QueriesConnectionString
    {
        public string Value { get; }

        public QueriesConnectionString(string value)
        {
            Value = value;
        }
    }
}
