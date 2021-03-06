﻿using Atlas.Core.Objects.Update;
using Atlas.ECS.Systems;
using AtlasTesting.ECS.Components;
using AtlasTesting.ECS.Families;
using System.Diagnostics;

namespace AtlasTesting.ECS.Systems
{
	class TestSystem1 : AtlasFamilySystem<TestMember>, ITestSystem1
	{
		public TestSystem1()
		{
			UpdateStep = TimeStep.Variable;
			DeltaIntervalTime = 5;
		}

		protected override void SystemUpdate(float deltaTime)
		{
			Debug.WriteLine($"{GetType().Name} Update");
			base.SystemUpdate(deltaTime);
		}

		override protected void MemberUpdate(float deltaTime, TestMember member)
		{
			Debug.WriteLine(member.Entity.GlobalName);
			//member.Entity.Parent.RemoveSystem<ITestSystem1>();
			if(member.Entity.GlobalName.Contains("-3"))
			{
				member.Entity.RemoveComponent<ITestComponent>();
			}
		}
	}
}
