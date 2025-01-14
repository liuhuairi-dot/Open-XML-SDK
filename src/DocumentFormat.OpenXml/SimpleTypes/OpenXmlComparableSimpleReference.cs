﻿// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System;

namespace DocumentFormat.OpenXml
{
    /// <summary>
    /// Represents a comparable and equatable reference.
    /// </summary>
    /// <typeparam name="T">The type of the value.</typeparam>
    public abstract class OpenXmlComparableSimpleReference<T> : OpenXmlSimpleType,
        IComparable, IComparable<OpenXmlComparableSimpleReference<T>>, IEquatable<OpenXmlComparableSimpleReference<T>>
        where T : class, IComparable, IComparable<T>, IEquatable<T>
    {
        /// <summary>
        /// Creates a new instance of <see cref="OpenXmlComparableSimpleReference{T}"/>.
        /// </summary>
        private protected OpenXmlComparableSimpleReference()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="OpenXmlComparableSimpleReference{T}"/>
        /// class by deep copying the supplied <see cref="OpenXmlComparableSimpleReference{T}"/>
        /// value.
        /// </summary>
        /// <param name="source">The source <see cref="OpenXmlComparableSimpleReference{T}"/> instance.</param>
        private protected OpenXmlComparableSimpleReference(OpenXmlComparableSimpleReference<T> source) : base(source)
        {
        }

        /// <summary>
        /// Gets or sets the value of this instance.
        /// </summary>
        public abstract T? Value { get; set; }

        /// <inheritdoc />
        public int CompareTo(object? obj)
        {
            if (obj is null || !HasValue)
            {
                return 1;
            }
            else if (Value is null)
            {
                return -1;
            }
            else if (obj is OpenXmlComparableSimpleReference<T> other)
            {
                return CompareTo(other);
            }
            else if (obj is T t)
            {
                return Value.CompareTo(t);
            }
            else
            {
                return Value.CompareTo(obj);
            }
        }

        /// <inheritdoc />
        public int CompareTo(OpenXmlComparableSimpleReference<T>? other)
        {
            if (other is null || !HasValue)
            {
                return 1;
            }

            if (Value is null)
            {
                return other.Value is null ? 0 : -1;
            }

            if (other.Value is null)
            {
                return -1;
            }

            return Value.CompareTo(other.Value);
        }

        /// <inheritdoc />
        public bool Equals(OpenXmlComparableSimpleReference<T>? other)
        {
            return !(other is null) && Equals(Value, other.Value);
        }

        /// <inheritdoc />
        public override bool Equals(object? obj)
        {
            if (obj is null || !HasValue)
            {
                return false;
            }

            if (Value is null)
            {
                return false;
            }

            if (ReferenceEquals(this, obj))
            {
                return true;
            }

            if (obj is OpenXmlComparableSimpleReference<T> other)
            {
                return Equals(other);
            }

            if (obj is T otherValue)
            {
                return otherValue.Equals(Value);
            }

            return false;
        }

        /// <inheritdoc />
        public override int GetHashCode()
        {
            return Value?.GetHashCode() ?? 0;
        }

        /// <summary>
        /// Determines whether the specified operands are equal.
        /// </summary>
        /// <param name="left">The left operand, or null.</param>
        /// <param name="right">The right operand, or null.</param>
        /// <returns>True if the operands are equal; otherwise, false.</returns>
        public static bool operator ==(OpenXmlComparableSimpleReference<T>? left, OpenXmlComparableSimpleReference<T>? right)
        {
            if (left is null)
            {
                return right is null;
            }

            return left.Equals(right);
        }

        /// <summary>
        /// Determines whether the specified operands are not equal.
        /// </summary>
        /// <param name="left">The left operand, or null.</param>
        /// <param name="right">The right operand, or null.</param>
        /// <returns>True if the operands are not equal; otherwise, false.</returns>
        public static bool operator !=(OpenXmlComparableSimpleReference<T>? left, OpenXmlComparableSimpleReference<T>? right)
        {
            return !(left == right);
        }

        /// <summary>
        /// Determines whether the left operand is less than the right operand.
        /// </summary>
        /// <param name="left">The left operand, or null.</param>
        /// <param name="right">The right operand, or null.</param>
        /// <returns>True if the left operand is less than the right operand; otherwise, false.</returns>
        public static bool operator <(OpenXmlComparableSimpleReference<T>? left, OpenXmlComparableSimpleReference<T>? right)
        {
            return left is null ? !(right is null) : left.CompareTo(right) < 0;
        }

        /// <summary>
        /// Determines whether the left operand is less than or equal to the right operand.
        /// </summary>
        /// <param name="left">The left operand, or null.</param>
        /// <param name="right">The right operand, or null.</param>
        /// <returns>True if the left operand is less than or equal to the right operand; otherwise, false.</returns>
        public static bool operator <=(OpenXmlComparableSimpleReference<T>? left, OpenXmlComparableSimpleReference<T>? right)
        {
            return left is null || left.CompareTo(right) <= 0;
        }

        /// <summary>
        /// Determines whether the left operand is greater than the right operand.
        /// </summary>
        /// <param name="left">The left operand, or null.</param>
        /// <param name="right">The right operand, or null.</param>
        /// <returns>True if the left operand is greater than the right operand; otherwise, false.</returns>
        public static bool operator >(OpenXmlComparableSimpleReference<T>? left, OpenXmlComparableSimpleReference<T>? right)
        {
            return !(left is null) && left.CompareTo(right) > 0;
        }

        /// <summary>
        /// Determines whether the left operand is greater than or equal to the right operand.
        /// </summary>
        /// <param name="left">The left operand, or null.</param>
        /// <param name="right">The right operand, or null.</param>
        /// <returns>True if the left operand is greater than or equal to the right operand; otherwise, false.</returns>
        public static bool operator >=(OpenXmlComparableSimpleReference<T>? left, OpenXmlComparableSimpleReference<T>? right)
        {
            return left is null ? right is null : left.CompareTo(right) >= 0;
        }
    }
}
