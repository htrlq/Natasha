﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Natasha.CSharp.Template
{
    public class MethodConstraintTemplate<T> : ParameterTemplate<T> where T : MethodConstraintTemplate<T>, new()
    {

        public string ConstraintScript;
        public MethodConstraintTemplate()
        {

        }

        public T Constraint(string constraint)
        {
            ConstraintScript = constraint;
            return Link;
        }

        public T ConstraintAppend(string constraint)
        {
            ConstraintScript += constraint;
            return Link;
        }

        public override T BuilderScript()
        {
            // [attribute]
            // [access] [modifier] [type] [name]([parameters]) [{this}]
            base.BuilderScript();
            if (ConstraintScript != default)
            {
                _script.Append(' ');
                _script.Append(ConstraintScript);
            }
            return Link;
        }
    }
}
