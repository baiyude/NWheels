﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NWheels.DataObjects;
using NWheels.Entities;
using NWheels.Processing.Core;

namespace NWheels.Processing
{
    [EntityContract]
    public interface IWorkflowInstanceEntity
    {
        long Id { get; set; }

        //-----------------------------------------------------------------------------------------------------------------------------------------------------

        Guid WorkflowInstanceId { get; set; }

        //-----------------------------------------------------------------------------------------------------------------------------------------------------

        WorkflowState WorkflowState { get; set; }

        //-----------------------------------------------------------------------------------------------------------------------------------------------------

        DateTime CreatedAtUtc { get; set; }

        //-----------------------------------------------------------------------------------------------------------------------------------------------------

        DateTime UpdatedAtUtc { get; set; }

        //-----------------------------------------------------------------------------------------------------------------------------------------------------

        [PropertyContract.Required, PropertyContract.Validation.MaxLength(512)]
        string CodeBehindClrType { get; set; }

        //-----------------------------------------------------------------------------------------------------------------------------------------------------

        byte[] ProcessorSnapshot { get; set; }

        //-----------------------------------------------------------------------------------------------------------------------------------------------------

        TimeSpan TotalTime { get; set; }

        //-----------------------------------------------------------------------------------------------------------------------------------------------------

        TimeSpan TotalExecutionTime { get; set; }

        //-----------------------------------------------------------------------------------------------------------------------------------------------------

        TimeSpan TotalSuspensionTime { get; set; }

        //-----------------------------------------------------------------------------------------------------------------------------------------------------

        int TotalSuspensionCount { get; set; }
    }
}
