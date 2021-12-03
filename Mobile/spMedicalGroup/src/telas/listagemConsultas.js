import React, { Component } from 'react';
import { FlatList, Image, ImageBackground, StyleSheet, Text, View } from 'react-native';

import api from '../services/api';
import { TouchableOpacity } from 'react-native-gesture-handler';
import jwtDecode from 'jwt-decode';

import AsyncStorage from '@react-native-async-storage/async-storage';



export default class Consultas extends Component {
    constructor(props) {
        super(props);
        this.state = {
            listaMinhasConsultas: [],
        };
    }



    //função logout
    logout = async () => {
        try {
            await AsyncStorage.removeItem('userToken');
            this.props.navigation.navigate('Login')
        } catch (error) {
            console.warn(error);
        }
    };


    //listarConsultas
    listarConsultas = async () => {
        try {

            const token = await AsyncStorage.getItem('userToken');

            console.warn(jwtDecode(token));

            //role = ({jwtDecode(token).role};

            console.warn(jwtDecode(token).role);


            //MÉDICO
            if ((jwtDecode(token).role) == "2") {
                const resposta = await api.get('/Consultas/medico', {
                    headers: {
                        Authorization: 'Bearer ' + token
                    }
                });

                if (resposta.status === 200) {
                    const dadosApi = resposta.data;
                    this.setState({ listaMinhasConsultas: dadosApi });
                }

            }


            //PACIENTE
            if ((jwtDecode(token).role) == "3") {

                const resposta = await api.get('/Consultas/paciente', {
                    headers: {
                        Authorization: 'Bearer ' + token
                    }
                });

                if (resposta.status === 200) {
                    const dadosApi = resposta.data;
                    this.setState({ listaMinhasConsultas: dadosApi });
                    console.warn(listaMinhasConsultas);
                }

            }


        } catch (error) {
            console.warn(error);
        }
    };


    componentDidMount() {
        this.listarConsultas();
    }



    render() {
        return (
            <View style={styles.container}>
                <View style={styles.container2} >
                    <ImageBackground source={require('../imagens/FundoLista.png')} style={styles.backgoundImage} >
                        <View style={styles.posicaoIcone}>
                            <TouchableOpacity onPress={this.logout}>
                                <Image source={require('../imagens/logout.png')} style={styles.logout} />
                            </TouchableOpacity>
                        </View>
                        <View style={styles.textoTitulo}>
                            <Text style={styles.h1}>Minhas Consultas</Text>
                        </View>
                    </ImageBackground>

                </View>
                <View style={styles.main}>
                    <FlatList
                            //contentContainerStyle={styles.mainBodyContent}
                            data={this.state.listaMinhasConsultas}
                            keyExtractor={item => item.idConsulta}
                            renderItem={this.renderItem}/>
                </View>
            </View>
        )
    }

    renderItem = ({ item }) => (
        
        <View style={styles.container3}>
            <View style={styles.main}>
            <View style={styles.card}>
           
           <View style={styles.titulo}>
               <Text style={styles.h2}>Atendimento</Text>
           </View>

           <View style={styles.conteudoAtendimento}>
               <View style={styles.info1}>
                   <View>
                       <Text style={styles.h3}>Médico</Text>
                       <Text style={styles.pConsulta}>{(item.idMedicoNavigation.nomeMedico)
                       }</Text>
                       {/* <Text style={styles.pConsulta}>{item.idMedicoNavigation.nomeMedico}</Text> */}
                   </View>
                   <View>
                       <Text style={styles.h3}>Clínica</Text>
                       {/* <Text style={styles.pConsulta}>{(item.idPacienteNavigation.idUsuarioNavigation.idClinicaNavigation.nomeClinica)}</Text> */}
                   </View>

                   <View>
                       <Text style={styles.h3}>Descrição</Text>
                       <Text style={styles.pConsulta}>{(item.descricao)}</Text>
                   </View>

               </View>
               <View style={styles.info2}>
                   <View>
                       <Text style={styles.h3}>Data e Hora</Text>
                       <Text style={styles.pConsulta}>{Intl.DateTimeFormat('pt-BR').format(new Date(item.dataConsulta))}</Text>
                   </View>
                   <View>
                       <Text style={styles.h3}>Especialidade</Text>
                       <Text style={styles.pConsulta}>{(item.idMedicoNavigation.idEspecialidadeNavigation.tituloEspecialidade)}</Text>
                   </View>
                   <View>
                       <Text style={styles.h3}>Situação</Text>
                       <Text style={styles.pConsulta}>{(item.idSituacaoNavigation.descricao)}</Text>
                   </View>
               </View>
           </View>

       </View>
            </View>
        </View>
       
    )


}

const styles = StyleSheet.create({
    container: {
        flex: 1
    },

    container2: {
        flex: 0.35,
        //backgroundColor: 'black'
    },

//    container3:{
// backgroundColor:'red'

//    },



    backgoundImage: {
        flex: 100,
        padding: 40,
        justifyContent: 'space-around'
    },

    posicaoIcone: {
        width: '100%',
        //marginTop: 20,
        alignItems: 'flex-end',
        //backgroundColor: 'red'
    },

    logout: {
        width: 25,
        height: 25
    },

    textoTitulo: {
        width: '100%',
        height: '100%',
        alignItems: 'center',
        justifyContent: 'center',
    },

    h1: {
        //backgroundColor: 'red',
        color: '#6D60F7',
        fontWeight: '700',
        //fontStyle: 'Poppins',
        fontSize: 40,
        fontFamily: "Poppins",
    },

    main: {
        backgroundColor: '#DEBFFF',
        flex: 0.65,
        alignItems: 'center',
        justifyContent: 'center'
    },

    card: {
        flex: 0.3,
        backgroundColor: '#FFF',
        // height: '150%',
        width: '100%',
        borderRadius: 15,
        justifyContent: 'space-around',
        padding: 30,

    },

    titulo: {
        flex: 1,
        // backgroundColor: 'green',
        // width: '100%',
        //backgroundColor: 'red',
        justifyContent: 'flex-start',
        alignItems: 'center'
    },

    h2: {
        fontWeight: '500',
        fontSize: 22,
        color: '#6D60F7',
    },

    conteudoAtendimento: {
        flex: 5,
        // height: '80%',
        //backgroundColor: 'red',
        //padding: 40,
        //flexDirection: 'column',
        justifyContent: 'space-between',
        flexDirection: 'row'
    },

    info1: {
       // flex: 1,
        justifyContent: 'space-between',
        // height: 50
    },

    info2: {
        //flex: 1,
        justifyContent: 'space-around',
        // height: 50
    },

    h3: {
        color: '#6D60F7',
        fontSize: 18,
        fontWeight: '500'
    },

    pConsulta: {
        color: '#000',
        fontSize: 18,
        fontWeight: '500'
    },

})