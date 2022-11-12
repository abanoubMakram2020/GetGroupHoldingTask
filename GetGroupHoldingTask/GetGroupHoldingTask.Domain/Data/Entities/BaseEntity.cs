using SharedKernal.Data;
using System;
using System.Collections.ObjectModel;

namespace GetGroupHoldingTask.Domain.Data
{
    public abstract class BaseEntity<TPrimaryKey> : /*ValueObject,*/ IEntity<TPrimaryKey>, ICreationSignature<int>/*, IModificationSignature<int?>*/
    {
        public TPrimaryKey Id { get; set; }
        public int CreatedBy { get; set; } = 1;
        public DateTime DateCreated { get; set; }
        //public int? ModifiedBy { get; set; }
        //public DateTime? DateModified { get; set; }
    }
}
