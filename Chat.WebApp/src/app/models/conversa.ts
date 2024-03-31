import { Mensagem } from "./mensagem";

export interface Conversa {
	id: string;
	contatoId: string;
	titulo: string;
	mensagens: Mensagem[] | undefined;
	dataCriacao: Date;
	dataAtualizacao: Date;
}
