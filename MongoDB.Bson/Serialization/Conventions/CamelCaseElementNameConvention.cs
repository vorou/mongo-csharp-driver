﻿/* Copyright 2010-2013 10gen Inc.
*
* Licensed under the Apache License, Version 2.0 (the "License");
* you may not use this file except in compliance with the License.
* You may obtain a copy of the License at
*
* http://www.apache.org/licenses/LICENSE-2.0
*
* Unless required by applicable law or agreed to in writing, software
* distributed under the License is distributed on an "AS IS" BASIS,
* WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
* See the License for the specific language governing permissions and
* limitations under the License.
*/

using System;
using System.Reflection;

namespace MongoDB.Bson.Serialization.Conventions
{
    /// <summary>
    /// A convention that sets the element name the same as the member name with the first character lower cased.
    /// </summary>
#pragma warning disable 618 // about obsolete IElementNameConvention
    public class CamelCaseElementNameConvention : ConventionBase, IMemberMapConvention, IElementNameConvention
#pragma warning restore 618
    {
        // public methods
        /// <summary>
        /// Applies a modification to the member map.
        /// </summary>
        /// <param name="memberMap">The member map.</param>
        public void Apply(BsonMemberMap memberMap)
        {
            string name = memberMap.MemberName;
            name = GetElementName(name);
            memberMap.SetElementName(name);
        }

        /// <summary>
        /// Gets the element name for a member.
        /// </summary>
        /// <param name="member">The member.</param>
        /// <returns>The element name.</returns>
        [Obsolete("Use Apply instead.")]
        public string GetElementName(MemberInfo member)
        {
            string name = member.Name;
            return GetElementName(name);
        }

        // private methods
        private string GetElementName(string memberName)
        {
            if (memberName.Length == 0)
            {
                return "";
            }
            else if(memberName.Length <= 2)
            {
                return memberName.ToLowerInvariant();
            }
            else 
            {
                return memberName.Substring(0, 2).ToLowerInvariant() + memberName.Substring(2);
            }
        }
    }
}