//Jenkinsfile (Declarative Pipeline)
pipeline {
    agent any
    stages {
        stage('Deploy') {
            steps {
                retry(5) {
                    sh './flakey-deploy.sh'
                }

                timeout(time: 5, unit: 'MINUTES') {
                    sh './health-check.sh'
                }
            }
        }
    }
}
