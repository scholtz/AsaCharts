using Newtonsoft.Json.Converters;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace AsaCharts.Model.Enums
{
    
    public enum ResultTypeEnum
    {
        [EnumMember(Value = "ok")]
        Ok,
        [EnumMember(Value = "no_data")]
        NoData,
        [EnumMember(Value = "error")] 
        Error
    }
}
