// Copyright © Christopher Dorst. All rights reserved.
// Licensed under the GNU General Public License, Version 3.0. See the LICENSE document in the repository root for license information.

using DevOps.Code.Entities.Interfaces.StaticEntity;
using Position = ProtoBuf.ProtoMemberAttribute;
using ProtoBufSerializable = ProtoBuf.ProtoContractAttribute;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq.Expressions;

namespace Entities.StaticFooBars
{
    /// <summary>Contains the StaticFooBar entity type</summary>
    [ProtoBufSerializable]
    [Table("StaticFooBars", Schema = "EntitiesStaticFooBars")]
    public class StaticFooBar : IStaticEntity<StaticFooBar, int>
    {
        public StaticFooBar()
        {
        }

        public StaticFooBar(int baz, DateTimeOffset qux)
        {
            Baz = baz;
            Qux = qux;;
        }

        /// <summary>Contains Baz value</summary>
        [Position(2)]
        public int Baz { get; set; }

        /// <summary>Contains Qux value</summary>
        [Position(3)]
        public DateTimeOffset Qux { get; set; }

        /// <summary>StaticFooBar unique identifier (primary key)</summary>
        [Key]
        [Position(1)]
        public int StaticFooBarId { get; set; }

        /// <summary>Returns a value that uniquely identifies this entity type. Each entity type in the model has a unique identifier.</summary>
        public int GetEntityType() => 4;

        /// <summary>Returns the entity's unique identifier.</summary>
        public int GetKey() => StaticFooBarId;

        /// <summary>Returns an expression defining this entity's unique index (alternate key)</summary>
        public Expression<Func<StaticFooBar, object>> GetUniqueIndex() => entity => new { entity.Baz, entity.Qux };
    }
}
