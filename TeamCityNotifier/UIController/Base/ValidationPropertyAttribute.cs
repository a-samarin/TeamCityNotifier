using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeamCityNotifier.UIController.Base
{
    /// <summary>
	/// Used to mark data model property to specify that it is used in validation logic
	/// </summary>
	[AttributeUsage(AttributeTargets.Property)]
    public class ValidationPropertyAttribute : Attribute
    {
    }
}
