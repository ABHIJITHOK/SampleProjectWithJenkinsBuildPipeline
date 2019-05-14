node {
stage 'Checkout'
    checkout scm

stage 'Build'
    bat "\"C:/Program Files/dotnet/dotnet.exe\" restore \"$C:/Git/ABHIJITHOK/SampleProjectWithJenkinsBuildPipeline/SampleProjectWithJenkinsBuildPipeline.sln\""
    bat "\"C:/Program Files/dotnet/dotnet.exe\" build \"$C:/Git/ABHIJITHOK/SampleProjectWithJenkinsBuildPipeline/SampleProjectWithJenkinsBuildPipeline.sln\""
}