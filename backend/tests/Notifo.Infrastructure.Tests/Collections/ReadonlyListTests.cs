﻿// ==========================================================================
//  Notifo.io
// ==========================================================================
//  Copyright (c) Sebastian Stehle
//  All rights reserved. Licensed under the MIT license.
// ==========================================================================

using Notifo.Infrastructure.TestHelpers;

namespace Notifo.Infrastructure.Collections;

public class ReadonlyListTests
{
    [Fact]
    public void Should_return_empty_instance_for_empty_array()
    {
        var result = ReadonlyList.Create<int>();

        Assert.Same(ReadonlyList.Empty<int>(), result);
    }

    [Fact]
    public void Should_return_empty_instance_for_null_array()
    {
        var result = ReadonlyList.Create((int[]?)null);

        Assert.Same(ReadonlyList.Empty<int>(), result);
    }

    [Fact]
    public void Should_return_empty_instance_for_empty_enumerable()
    {
        var result = Enumerable.Empty<int>().ToReadonlyList();

        Assert.Same(ReadonlyList.Empty<int>(), result);
    }

    [Fact]
    public void Should_make_correct_equal_comparisons()
    {
        var list1a = ReadonlyList.Create(1);
        var list1b = ReadonlyList.Create(1);

        var listOtherValue = ReadonlyList.Create(2);
        var listOtherSize = ReadonlyList.Create(1, 2);

        Assert.Equal(list1a, list1b);
        Assert.Equal(list1a.GetHashCode(), list1b.GetHashCode());
        Assert.True(list1a.Equals((object)list1b));

        Assert.NotEqual(list1a, listOtherValue);
        Assert.NotEqual(list1a.GetHashCode(), listOtherValue.GetHashCode());
        Assert.False(list1a.Equals((object)listOtherValue));

        Assert.NotEqual(list1a, listOtherSize);
        Assert.NotEqual(list1a.GetHashCode(), listOtherSize.GetHashCode());
        Assert.False(list1a.Equals((object)listOtherSize));
    }

    [Fact]
    public void Should_serialize_and_deserialize()
    {
        var sut = ReadonlyList.Create(1, 2, 3);

        var serialized = sut.SerializeAndDeserialize();

        Assert.Equal(sut, serialized);
    }

    [Fact]
    public void Should_serialize_and_deserialize_bson()
    {
        var sut = ReadonlyList.Create(1, 2, 3);

        var serialized = sut.SerializeAndDeserializeBson();

        Assert.Equal(sut, serialized);
    }
}
