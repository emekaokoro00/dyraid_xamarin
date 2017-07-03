using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dyraid.Abstractions
{
    /// <summary>
    /// A type that mirrors the properties of Microsoft.Azure.Mobile.Server.EntityData.
    /// </summary>
    public interface IObservableEntityData
    {
        string Id { get; set; }

        DateTimeOffset CreatedAt { get; set; }

        DateTimeOffset UpdatedAt { get; set; }

        byte[] Version { get; set; }
    }
}
