//Jenkinsfile (Declarative Pipeline)
pipeline {
    agent any
    stages {
        stage('Deploy') {
            steps {
                timeout(time: 2, unit: 'MINUTES') {
                    retry(10) {
                        sh '/usr/local/security-group-manager/flakey-deploy.sh'
                    }
                }
            }
        }
    }
}
