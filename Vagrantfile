Vagrant.configure("2") do | config | 
    config.vm.define "web" do |web| 
        web.vm.box = "Ubuntu-Vagrant" 
        web.vm.hostname = "web.lab" 
        web.vm.provider "virtualbox" do |vb| 
            vb.customize ["modifyvm", :id, "--memory", "1024"] 
        end 
		web.vm.network "private_network", ip: "192.168.99.100" 
		web.vm.network "forwarded_port", guest: 80, host: 8000
        web.vm.network "forwarded_port", guest: 8080, host: 8080
        web.vm.provision "shell", path: "docker-setup.sh"
		config.vm.provision "file", source: "./WebCourseWork/", destination: "$HOME/WebCourseWork"
    end     
end 