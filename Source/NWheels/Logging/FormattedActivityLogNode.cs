﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NWheels.Logging
{
    public class FormattedActivityLogNode : ActivityLogNode
    {
        private readonly string _singleLineText;
        private readonly string _fullDetailsText;

        //-----------------------------------------------------------------------------------------------------------------------------------------------------

        public FormattedActivityLogNode(string singleLineText, string fullDetailsText = null)
        {
            _singleLineText = singleLineText;
            _fullDetailsText = fullDetailsText;
        }

        //-----------------------------------------------------------------------------------------------------------------------------------------------------

        protected override string FormatSingleLineText()
        {
            return _singleLineText;
        }

        //-----------------------------------------------------------------------------------------------------------------------------------------------------

        protected override string FormatFullDetailsText()
        {
            return _fullDetailsText;
        }
    }
}
