﻿node {
	stage 'Checkout'
		checkout scm

	stage 'Build'
		bat "\"${tool 'MSBuild'}\" SampleProjectWithJenkinsBuildPipeline.sln /p:Configuration=Release /p:Platform=\"Any CPU\" /p:ProductVersion=1.0.0.${env.BUILD_NUMBER}"

}