pipeline {
    agent any

    stages {
        stage('Checkout') {
            steps {
                echo 'Checking out the code'
                checkout scm
            }
        }

        stage('Build and Test') {
            steps {
                echo 'Starting Build and Test'
                script {
                    def targetDirectory = 'C:\\Temp\\Deployment\\ProductMicroservice'
                    bat "dotnet restore ProductMicroservice/ProductMicroservice/ProductMicroservice.csproj"
                    bat "dotnet build ProductMicroservice/ProductMicroservice/ProductMicroservice.csproj"
                    bat "dotnet test ProductMicroservicesTest/ProductMicroservicesTest.csproj"
                    bat "dotnet publish ProductMicroservice/ProductMicroservice/ProductMicroservice.csproj -c Release -o ${targetDirectory}"
                }
            }
        }

        stage('Deploy') {
            steps {
                echo 'Starting Deploy'
                script {
                    def targetDirectory = 'C:\\Temp\\Deployment\\ProductMicroservice'
                    // bat "mkdir ${targetDirectory}"
                    bat "xcopy /s /y .\\ProductMicroservice\\ProductMicroservice\\bin\\Release\\net8.0\\net8.0\\* ${targetDirectory}"
                   // bat "cd ${targetDirectory}"
           // bat "dotnet ProductMicroservice.dll"  // Assuming this is the command to start your application
        
                }
            }
        }
    }

    post {
        success {
            echo 'Build successful - Add any additional success steps here'
        }
        failure {
            echo 'Build failed - Add any additional failure steps here'
        }
    }
}
