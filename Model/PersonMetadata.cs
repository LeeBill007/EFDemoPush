using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;


namespace Model
{
    [MetadataType(typeof(PersonMetadata))]
    public partial class Person
    {
        public class PersonMetadata
        {
            public int Id { get; set; }
            [MaxLength(3, ErrorMessage = "長度只能為三個")]
            public string Name { get; set; }
            //[Range(1, 100, ErrorMessage = "年齡只能100歲以內")]
            [MaxAge(100,ErrorMessage = "年齡只能100歲以內")]
            public Nullable<int> Age { get; set; }
            public string Gender { get; set; }
        }
    }
}