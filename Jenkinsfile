node {
	stage 'Build'
		bat 'nuget restore SampleProjectWithJenkinsBuildPipeline.sln'
		bat "\"${tool 'MSBuild'}\" SampleProjectWithJenkinsBuildPipeline.sln /p:Configuration=Release /p:Platform=\"Any CPU\" /p:ProductVersion=1.0.0.${env.BUILD_NUMBER}"

	stage 'Archive'
		archive 'MyConsoleApp1/bin/Release/**'

}