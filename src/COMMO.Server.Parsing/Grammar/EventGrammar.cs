// <copyright file="EventGrammar.cs" company="2Dudes">
// Copyright (c) 2018 2Dudes. All rights reserved.
// Licensed under the MIT license.
// See LICENSE file in the project root for full license information.
// </copyright>

using System;
using System.Linq;
using COMMO.Data.Contracts;
using Sprache;

namespace COMMO.Server.Parsing.Grammar
{
    public class EventGrammar
    {
        public static readonly Parser<MoveUseEvent> Event =
            from rule in CipGrammar.ConditionalActionRule
            select new MoveUseEvent(rule);

        public class MoveUseEvent
        {
            public ItemEventType Type { get; }

            public ConditionalActionRule Rule { get; }

            public MoveUseEvent(ConditionalActionRule rule)
            {
                if (rule == null)
                {
                    throw new ArgumentNullException(nameof(rule));
                }

                var firstCondition = rule.ConditionSet.FirstOrDefault();

                ItemEventType eventType;

                if (!Enum.TryParse(firstCondition, out eventType))
                {
                    throw new ArgumentException("Invalid rule supplied.");
                }

                Type = eventType;
                Rule = rule;

                rule.ConditionSet.RemoveAt(0); // remove first.
            }
        }
    }
}
