node {
stage 'Checkout'
    checkout scm

stage 'Build'
    bat "\"C:/Program Files/dotnet/dotnet.exe\" restore \"${workspace}/SampleProjectWithJenkinsBuildPipeline.sln\""
    bat "\"C:/Program Files/dotnet/dotnet.exe\" build \"${workspace}/SampleProjectWithJenkinsBuildPipeline.sln\""
}