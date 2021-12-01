import React, { Component } from 'react';
import {
    Image,
    TouchableOpacity,
    StatusBar,
    StyleSheet,
    View,
    Text,
    TextInput
} from 'react-native';
//import { TextInput } from 'react-native-gesture-handler';

import api from '../services/api';

export default class Login extends Component {
    constructor(props) {
        super(props);
        this.state = {
            email: '',
            senha: ''
        };
    }


    login = async () => {

        const resposta = await api.post('/Login',
        {
            email: this.state.email, 
            senha: this.state.senha
        });

        const token = resposta.data.token;
        await AsyncStorage.setItem('userToken', token);

        if (resposta.data.status === 200) {
            this.props.navigation.navigate('Main');
        }

        console.warn(token);

    }


    render() {
        return (
            <View style={styles.container}>
                    <Image
                        source={require('../imagens/Logo_3.png')}
                        style={styles.iconeLogin}
                    />
                    <View style={styles.itensLogin}>
                        <TextInput style={styles.inputLogin}
                            placeholder=" Email:"
                            placeholderTextColor="#6D60F7"
                            keyboardType="email-address"
                            onChangeText={email => this.setState({ email })}
                        />
                        <TextInput style={styles.inputLogin}
                            placeholder=" Senha:"
                            placeholderTextColor="#6D60F7"
                            keyboardType="default"
                            secureTextEntry={true}
                            onChangeText={senha => this.setState({ senha })}
                        />
                        <TouchableOpacity
                            style={styles.btnLogin}
                            onPress={this.login}>
                            <Text style={styles.btnLoginText}>Login</Text>
                        </TouchableOpacity>
                    </View>
            </View>
        )
    }

}

const styles = StyleSheet.create({
    container:{
        flex:1,
        backgroundColor: '#6D60F7',
        alignItems: 'center',
        justifyContent: 'center'
    },

    iconeLogin: {
        height: 90,
        width: 90,
        marginBottom: 30
    },

    itensLogin: {
        flex: 0.35,
        //backgroundColor: 'black',
        alignItems: 'center',
        justifyContent: 'space-around'
    },

    inputLogin: {
        width: 240,
        height: 40,
        backgroundColor: '#FFF',
        borderRadius: 10,
        alignItems: 'center',
        borderColor: 'white',
        fontSize: 16,
        fontWeight: '600'
    },

    btnLogin:{
        width: 240,
        height: 45,
        backgroundColor:'',
        alignItems: 'center',
        justifyContent: 'center',
        borderRadius: 10,
        borderWidth: 3,
        borderColor: '#FFF'
    },

    btnLoginText:{
        color: '#FFF',
        fontSize: 16,
        textTransform: 'uppercase'
    }
});