﻿using Bunit;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Bit.Client.Web.BlazorUI.Tests.Checkboxes
{
    [TestClass]
    public class BitCheckboxTests : BunitTestContext
    {
        [DataTestMethod, DataRow(true, true, false),
            DataRow(false, true, true),
            DataRow(true, false, true),
            DataRow(false, false, false)]
        public void BasicCheckbox_OnClick_MeetExpectedValue(bool isChecked, bool isEnabled, bool afterClickHasCheckedClass)
        {
            Context.JSInterop.Mode = JSRuntimeMode.Loose;

            var component = RenderComponent<BitCheckboxTest>(parameters => parameters
                .Add(p => p.IsEnabled, isEnabled).Add(p => p.IsChecked, isChecked));

            var bitCheckbox = component.Find(".bit-chb-container-fluent > div > div");
            bitCheckbox.Click();

            var bitCheckboxContainer = component.Find(".bit-chb-container-fluent");
            Assert.AreEqual(afterClickHasCheckedClass, bitCheckboxContainer.ClassList.Contains("bit-chb-container-checked-fluent"));
        }

        [DataTestMethod, DataRow(true, true, false), DataRow(true, false, true)]
        public void IndeterminatedCheckbox_OnClick_MeetExpectedValue(bool isIndeterminate, bool isEnabled, bool afterClickHasIndeterminateClass)
        {
            Context.JSInterop.Mode = JSRuntimeMode.Loose;

            var component = RenderComponent<BitCheckboxTest>(parameters => parameters
                .Add(p => p.IsIndeterminate, isIndeterminate)
                .Add(p => p.IsEnabled, isEnabled));

            var bitCheckbox = component.Find(".bit-chb-container-fluent > div > div");
            bitCheckbox.Click();

            var bitCheckboxContainer = component.Find(".bit-chb-container-fluent");
            Assert.AreEqual(afterClickHasIndeterminateClass, bitCheckboxContainer.ClassList.Contains("bit-chb-container-indeterminate-fluent"));
        }

        [DataTestMethod, DataRow(true, true, true, true), DataRow(true, false, true, false)]
        public void IndeterminatedCheckboxWidthIsCheckedValue_OnClick_MeetExpectedValue(bool isIndeterminate, bool isChecked, bool isEnabled, bool afterClickHasCheckedClass)
        {
            Context.JSInterop.Mode = JSRuntimeMode.Loose;

            var component = RenderComponent<BitCheckboxTest>(parameters => parameters
                .Add(p => p.IsIndeterminate, isIndeterminate)
                .Add(p => p.IsChecked, isChecked));

            var bitCheckbox = component.Find(".bit-chb-container-fluent > div > div");
            bitCheckbox.Click();

            var bitCheckboxContainer = component.Find(".bit-chb-container-fluent");
            Assert.AreEqual(afterClickHasCheckedClass, bitCheckboxContainer.ClassList.Contains("bit-chb-container-checked-fluent"));
        }
    }
}
